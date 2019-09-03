using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using App1_NossoChat.Util;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        //private StackLayout SL;
        //UsuarioUtil.GetUsuarioLogado();
        private Chat chat;
        private List<Mensagem> _mensagens;
        public List<Mensagem> Mensagens
        {
            get { return _mensagens; }
            set
            {
                _mensagens = value;
                OnPropertyChanged("Mensagens");
            }
        }

        private string _txtMensagem;
        public string TxtMensagem
        {
            get { return _txtMensagem; }
            set
            {
                _txtMensagem = value;
                OnPropertyChanged("TxtMensagem");
            }
        }

        public Command BtnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public MensagemViewModel(Chat chat)
        {
            this.chat = chat;
            Atualizar();
            BtnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(Atualizar);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Atualizar();
                return true;
            });
        }
        private void Atualizar()
        {
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }

        private void BtnEnviar()
        {
            var msg = new Mensagem()
            {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };
            ServiceWS.InsertMensagem(msg);
            Atualizar();
            TxtMensagem = string.Empty;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
