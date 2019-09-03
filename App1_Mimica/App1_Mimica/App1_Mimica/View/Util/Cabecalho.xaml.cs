using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View.Util
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cabecalho : ContentView
	{
		public Cabecalho ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.CabecalhoViewModel();
		}

        //Ação para quando não tem um command na propriedade para poder fazer uma chamada...
        private void SairEvento(object sender, EventArgs e)
        {
            var viewModel =  (ViewModel.CabecalhoViewModel)this.BindingContext;

            if (viewModel.Sair.CanExecute(null))
            {
                viewModel.Sair.Execute(null);
            }
        }
    }
}