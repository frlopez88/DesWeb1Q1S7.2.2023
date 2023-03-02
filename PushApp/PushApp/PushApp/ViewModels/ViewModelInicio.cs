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

        public ViewModelInicio( )
        {
            getPersonas();
            
        }

        private async void getPersonas()
        {

            ListPersonas = new ObservableCollection<persona>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<persona>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
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

        string usuario;
        public string Usuario { 
            get=> usuario;
            set{ 
            
                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
