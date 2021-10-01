using DropDownMenu.Base;
using DropDownMenu.Commands;
using DropDownMenu.Message;
using DropDownMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DropDownMenu
{
    class FirstView : ViewModelBase
    {

        private readonly string _directoryName;
        private ICommand _imageListCommand;
        private ICommand _barcodeCommand;
        private List<ImageDetailViewModel> _list = new List<ImageDetailViewModel>();
        private ICommand _showCommand;

        public FirstView(string directoryName)
        {
        _directoryName = directoryName;
        LoadDirectories(directoryName);
        LoadAllImages(directoryName);
        }

        public ICommand BarcodeCommand => _barcodeCommand ?? (_barcodeCommand = new RelayCommand(i => BarcodeCommandMethod()));
        public ICommand ShowCommand => _showCommand ?? (_showCommand = new RelayCommand(i => ShowCommandMethod((ImageDetailViewModel)i)));
        public ICommand ImageListCommand => _imageListCommand ?? (_imageListCommand = new RelayCommand(i => ImageListCommandMethod((string)i)));

        public List<string> DirectoryList { get; set; } = new List<string>();
        public List<ImageDetailViewModel> ImageDetailList => new List<ImageDetailViewModel>();

       
        private void ShowCommandMethod(ImageDetailViewModel item)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(item.Path, UriKind.Relative);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();

            var form = new ImageWindow { Image = { Source = image } };
            form.ShowDialog();
        }
        private void BarcodeCommandMethod()
        {
          MessengerInstance.Send(new ReloadMessage(new FirstView("Images")));
        }

        private void ImageListCommandMethod(string name)
        {
          var path = $"{_directoryName}\\{name}";
          MessengerInstance.Send(new ReloadMessage(new FirstView(path)));
        }

        private void LoadAllImages(string path)
        {
            var files = Directory.GetFiles(path).ToList();
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                _list.Add(new ImageDetailViewModel
                {
                    Name = fileInfo.Name,
                    Path = file
                });
            }

        }
        private void LoadDirectories(string directoryName)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{directoryName}";
            var directories = Directory.GetDirectories(path);
            DirectoryList.AddRange(directories.Select(directory => new DirectoryInfo(directory).Name).ToList());
        }



    }
    
}
