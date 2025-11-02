Feature: NuevaCompra

Background: 
Given el usuario ingresa al ambiente 'http://161.132.67.82:31097/'
When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
And accede al módulo 'Compra'
And accede al submódulo 'Nueva Compra'


@RegistrarCompra
Scenario: Registro de una nueva compra
	When el usuario agrega el codigo de barras '400000891'
	And ingresa la cantidad '2'
	And ingresa el v.unitario '150.00'
    And aplica un descuento de '10.00' soles 
	And selecciona una fecha de vencimiento '30/12/2024'
	And ingresa el precio del flete '20.00'
	And ingresar proveedor '75521712'
	And ingresar fecha de envio ''
	And seleccionar el tipo de documento 'BOLETA DE VENTA ELECTRONICA'
	And ingresar una serie '0001'
	Then la compra se completo correctamente


