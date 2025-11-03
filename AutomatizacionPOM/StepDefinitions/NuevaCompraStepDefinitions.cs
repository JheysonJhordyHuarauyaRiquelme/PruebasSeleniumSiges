using AutomatizacionPOM.Pages;
using NUnit.Framework;
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
            
        }

        [When("seleccionar el tipo de documento {string}")]
        public void WhenSeleccionarElTipoDeDocumento(string tipoDocumento)
        {
            registroCompraPage.SeleccionarTipoDocumento(tipoDocumento);
        }

        [When("ingresar una serie {string}")]
        public void WhenIngresarUnaSerie(string serie)
        {
            registroCompraPage.IngresarSerie(serie);
        }
        [When("ingresar el numero de documento {string}")]
        public void WhenIngresarElNumeroDeDocumento(string numeroDoc)
        {
            registroCompraPage.IngresarNumeroDocumento(numeroDoc);
        }

        [When("ingresar una observacion {string}")]
        public void WhenIngresarUnaObservacion(string observacion)
        {
            registroCompraPage.IngresarObservacion(observacion);
        }

        [When("seleccionar opcion de rol {string}")]
        public void WhenSeleccionarOpcionDeRol(string opcionRol)
        {
            registroCompraPage.SeleccionarOpcionRol(opcionRol);
        }

        [When("selecciona un tipo de pago {string}")]
        public void WhenSeleccionaUnTipoDePago(string tipoPago)
        {
            registroCompraPage.SeleccionarTipoPago(tipoPago);
        }

        [When("ingresa la observacion del metodo de pago {string}")]
        public void WhenIngresaLaObservacionDelMetodoDePago(string observacionPago)
        {
            registroCompraPage.IngresarObservacionMetodoPago(observacionPago);
        }

        [When("selecciona el tipo de compra {string}")]
        public void WhenSeleccionaElTipoDeCompra(string tipoCompra)
        {
            registroCompraPage.SeleccionarTipoCompra(tipoCompra);
        }

        [Then("la compra se completo correctamente")]
        public void ThenLaCompraSeCompletoCorrectamente()
        {
            registroCompraPage.GuardarCompra();
        }

    }
}
