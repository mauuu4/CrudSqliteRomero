namespace CrudSqliteRomero
{
    public partial class MainPage : ContentPage
    {
        private Motos motos;

        public MainPage()
        {
            InitializeComponent();
            motos = new Motos();
        }

        private async void cmdCrear_Clicked(object sender, EventArgs e)
        {
            if (!await TryGetIdAsync() || !await TryGetAnioAsync())
                return;

            var id = int.Parse(txtId.Text);
            var anio = int.Parse(txtAnio.Text);

            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                await DisplayAlertAsync("Datos incompletos", "Ingresa marca y modelo.", "OK");
                return;
            }

            try
            {
                var nuevaMoto = motos.Create(
                    id,
                    txtMarca.Text,
                    txtModelo.Text,
                    anio
                );

                await DisplayAlertAsync("Moto creada", $"Se ha creado la moto {nuevaMoto.Marca} {nuevaMoto.Modelo} con ID {nuevaMoto.Id}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error al crear", ex.Message, "OK");
            }
        }

        private async void cmdLerr_Clicked(object sender, EventArgs e)
        {
            if (!await TryGetIdAsync())
                return;

            var id = int.Parse(txtId.Text);

            var moto = motos.ReadById(id);
            if (moto != null)
            {
                txtMarca.Text = moto.Marca;
                txtModelo.Text = moto.Modelo;
                txtAnio.Text = moto.Anio.ToString();
            }
            else
            {
                await DisplayAlertAsync("Moto no encontrada", $"No se encontró una moto con ID {txtId.Text}", "OK");
            }
        }

        private async void cmdActualizar_Clicked(object sender, EventArgs e)
        {
            if (!await TryGetIdAsync() || !await TryGetAnioAsync())
                return;

            var id = int.Parse(txtId.Text);
            var anio = int.Parse(txtAnio.Text);

            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                await DisplayAlertAsync("Datos incompletos", "Ingresa marca y modelo.", "OK");
                return;
            }

            try
            {
                motos.Update(
                    id,
                    txtMarca.Text,
                    txtModelo.Text,
                    anio
                );

                await DisplayAlertAsync("Moto actualizada", $"Se ha actualizado la moto con ID {txtId.Text}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error al actualizar", ex.Message, "OK");
            }
        }

        private async void cmdBorrar_Clicked(object sender, EventArgs e)
        {
            if (!await TryGetIdAsync())
                return;

            var id = int.Parse(txtId.Text);
            var idTexto = txtId.Text;

            try
            {
                motos.Delete(id);
                txtId.Text = "";
                txtAnio.Text = "";
                txtModelo.Text = "";
                txtMarca.Text = "";

                await DisplayAlertAsync("Moto eliminada", $"Se ha eliminado la moto con ID {idTexto}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error al eliminar", ex.Message, "OK");
            }
        }

        private async Task<bool> ShowValidacionAsync(string mensaje)
        {
            await DisplayAlertAsync("Validación", mensaje, "OK");
            return false;
        }

        private async Task<bool> TryGetIdAsync()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                return await ShowValidacionAsync("Ingresa un Id.");

            if (!int.TryParse(txtId.Text, out _))
                return await ShowValidacionAsync("El Id debe ser numérico.");

            return true;
        }

        private async Task<bool> TryGetAnioAsync()
        {
            if (string.IsNullOrWhiteSpace(txtAnio.Text))
                return await ShowValidacionAsync("Ingresa el año.");

            if (!int.TryParse(txtAnio.Text, out _))
                return await ShowValidacionAsync("El año debe ser numérico.");

            return true;
        }
    }
}
