using ConsultaCep.Models;
using ConsultaCep.Services;

namespace ConsultaCep
{
    public partial class MainPage : ContentPage

    {
        private ICepService _cepService;



        public MainPage()
        {

            InitializeComponent();
            _cepService = new CepService();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {

                string cepInput = cepEntry.Text;


                if (!string.IsNullOrWhiteSpace(cepInput) && cepInput.Length == 8)
                {

                    if (int.TryParse(cepInput, out int cepToQuery))
                    {

                        Cep cepInfo = await _cepService.GetCep(cepToQuery);



                        logradouroLabel.Text = cepInfo.logradouro;
                        bairroLabel.Text = cepInfo.bairro;
                        cidadeLabel.Text = cepInfo.localidade;
                        estadoLabel.Text = cepInfo.uf;
                    }
                }
                else
                {
                    throw new Exception("Quantidade de numeros invalida");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", $"Erro ao consultar o CEP: {ex.Message}", "OK");
            }


        }
    }
}