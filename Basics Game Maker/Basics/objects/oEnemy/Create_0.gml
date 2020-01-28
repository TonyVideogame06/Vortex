/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
if(hasweapon)
{
	mygun = instance_create_layer(x,y,"Gun",oEGun)
	with(mygun)
	{
		owner = other.id;
	}
	
}
else
{
	mygun = noone;
}