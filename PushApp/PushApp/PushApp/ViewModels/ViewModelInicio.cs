using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PushApp.Models;

namespace PushApp.ViewModels
{
    public class ViewModelInicio : INotifyPropertyChanged
    {

        public ViewModelInicio()
        {
            
        }

        


        string url = "https://desfrlopez.me/ejemplo/api/persona";

        ObservableCollection<persona> listPersonas = new ObservableCollection<persona>();

        public ObservableCollection<persona> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
