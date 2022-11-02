using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2022222.WPFClient
{
    public class PublisherEditorViewModel : ObservableRecipient
    {
        public RestCollection<Publisher> Publishers { get; set; }

        private Publisher selectedpublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedpublisher; }
            set 
            {
                if (value != null)
                {
                    selectedpublisher = new Publisher()
                    {
                        PublisherName = value.PublisherName,
                        PublisherId = value.PublisherId,
                    };
                    OnPropertyChanged();
                    (DeletePublisherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreatePublisherCommand { get; set; }
        public ICommand DeletePublisherCommand { get; set; }
        public ICommand UpdatePublisherCommand { get; set; }
        public PublisherEditorViewModel()
        {
           
            if (!IsInDesignMode)
            {

                Publishers = new RestCollection<Publisher>("http://localhost:51783/", "Publisher","hub");

                CreatePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Add(new Publisher()
                    {
                        PublisherName = SelectedPublisher.PublisherName
                    }) ;
                }
                );

                UpdatePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Update(SelectedPublisher);
                });

                DeletePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Delete(SelectedPublisher.PublisherId);
                },
                () =>
                {
                    return SelectedPublisher != null;
                });
                SelectedPublisher = new Publisher();
            }
        }
    }
}
