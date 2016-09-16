using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace UsingTimer
{
    public sealed class ImageDisplayer : Control
    {
        #region fieid 字段
        DispatcherTimer time = new DispatcherTimer();
        private static Image image;
        int i = 1;
        #endregion


        #region property
        /// <summary>
        /// 是否在显示动画
        /// </summary>
        public bool IsShow { get; private set; }
        /// <summary>
        /// List<BitmapImage> Images循环显示的集合
        /// </summary>
        public List<BitmapImage> Images { get; set; }
        #endregion

        #region dependencyProperty
        /// <summary>
        /// 用于显示的Image绑定的Source属性
        /// </summary>
        public ImageSource ImageSourceNormal
        {
            get { return (ImageSource)GetValue(ImageSourceNormalProperty); }
            set { SetValue(ImageSourceNormalProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceNormalProperty = DependencyProperty.Register("ImageSourceNormal", typeof(ImageSource), typeof(ImageDisplayer), new PropertyMetadata(null));
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ImageDisplayer()
        {
            this.DefaultStyleKey = typeof(ImageDisplayer);
        }

        /// <summary>
        /// 计时器操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Time_Tick(object sender, object e)
        {
            if (image == null || Images == null)
            {
                time.Stop();
                IsShow = false;
                return;
            }
            if (i >= Images.Count)
            {
                i = 1;
            }
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ImageSourceNormal = Images[i];
            });
            i++;
        }

        /// <summary>
        /// 重用模板时启用
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            image = GetTemplateChild("image") as Image;
            time.Tick += Time_Tick;
            time.Interval = TimeSpan.FromMilliseconds(100);
        }



        /// <summary>
        /// 开始计时器
        /// </summary>
        public void Show()
        {
            time.Start();
            IsShow = true;
        }
        /// <summary>
        /// 停止计时器
        /// </summary>
        public void Stop()
        {
            time.Stop();
        }



    }
}
