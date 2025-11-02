using AutomatizacionPOM.Pages;
using OpenQA.Selenium;
using Reqnroll;
using System;

namespace AutomatizacionPOM.StepDefinitions
{
    [Binding]
    public class NuevaCompraStepDefinitions
    {
        private IWebDriver driver;
        RegistroCompraPage registroCompraPage;
        public NuevaCompraStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            registroCompraPage = new RegistroCompraPage(driver);
        }

        [When("el usuario agrega el codigo de barras {string}")]
        public void WhenElUsuarioAgregaElCodigoDeBarras(string codigo)
        {
            registroCompraPage.IngresarCodigoBarra(codigo);
        }

        [When("ingresa la cantidad {string}")]
        public void WhenIngresaLaCantidad(string cantidad)
        {
            registroCompraPage.IngresarCantidad(cantidad);
        }

        [When("ingresa el v.unitario {string}")]
        public void WhenIngresaElV_Unitario(string valorUnitario)
        {
            registroCompraPage.IngresarValorUnitario(valorUnitario);
        }

        [When("aplica un descuento de {string} soles")]
        public void WhenAplicaUnDescuentoDeSoles(string descuento)
        {
            registroCompraPage.AplicaDescuento(descuento);
        }

        [When("selecciona una fecha de vencimiento {string}")]
        public void WhenSeleccionaUnaFechaDeVencimiento(string fecha_vencimiento)
        {
            registroCompraPage.SeleccionFV(fecha_vencimiento);
        }

        [When("ingresa el precio del flete {string}")]
        public void WhenIngresaElPrecioDelFlete(string flete)
        {
            registroCompraPage.IngresarFlete(flete);
        }

        [When("ingresar proveedor {string}")]
        public void WhenIngresarProveedor(string proveedor)
        {
            registroCompraPage.IngresarProveedor(proveedor);
        }

        [When("ingresar fecha de envio {string}")]
        public void WhenIngresarFechaDeEnvio(string fechaEnvio)
        {
            if (!string.IsNullOrWhiteSpace(fechaEnvio))
            {
                DateTime fechaIngresada;
                if (DateTime.TryParse(fechaEnvio, out fechaIngresada))
                {
                    if (fechaIngresada <= DateTime.Today)
                    {
                        registroCompraPage.IngresarFechaEnvio(fechaEnvio);
                    }
                    else
                    {
                        throw new ArgumentException($"La fecha de envío '{fechaEnvio}' no puede ser futura.");
                    }
                }
                else
                {
                    throw new FormatException($"La fecha '{fechaEnvio}' no tiene un formato válido (usa dd/MM/yyyy).");
                }
            }
            else
            {
                Console.WriteLine("No se ingresó fecha de envío, se usará la fecha actual por defecto.");
            }
        }


        [When("seleccionar el tipo de documento {string}")]
        public void WhenSeleccionarElTipoDeDocumento(string tipoDocumento)
        {
            if (!string.IsNullOrWhiteSpace(tipoDocumento) && !tipoDocumento.Contains("(vacío)"))
                registroCompraPage.SeleccionarTipoDocumento(tipoDocumento);
        }

        [When("ingresar una serie {string}")]
        public void WhenIngresarUnaSerie(string serie)
        {
            registroCompraPage.IngresarSerie(serie);
        }

    }
}
