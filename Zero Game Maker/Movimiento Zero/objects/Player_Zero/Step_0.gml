/// @description 
// Puede escribir su código en este editor
#region //Validacion si el Zero esta saltando o cayendo
if vspeed > 0
{
	fall = true;
}
else
{
	fall = false;
}
if vspeed < 0
{
	up = true;
}
else
{
	up = false;
}
#endregion
#region //Gravedad
if place_free(x,y+1)
{
	gravity = 1;
}
else
{
	gravity = 0;
}
if vspeed >= 20 {vspeed = 20;}
#endregion


var Der = keyboard_check(vk_right);
var Izq = keyboard_check(vk_left);
if Der {Izq = false;}
if Izq {Der = false;}
var Sal = keyboard_check_pressed(vk_space);
if !keyboard_key
{
	if fall == true
		sprite_index = zero_cayendo;
	else
	if up
		sprite_index = zero_saltando;
	else
		sprite_index = zero_parado;
	
	image_speed = 0.5;
}
if Sal && !place_free(x,y+1) || Sal && Der || Sal && Izq 
{
 
  sprite_index = zero_saltando;
  vspeed = -salto;

}
if Der
{
  x += vel;
  sprite_index = zero_derecha;
  image_speed = 0.5;

}
if Izq
{ 
  x -= vel;
  sprite_index = zero_izquierda;
  image_speed = 0.5;
}





/*
key_left = keyboard_check(vk_left);
key_right = keyboard_check(vk_right);
key_jump = keyboard_check_pressed(vk_up);

var move = key_right - key_left;

hsp = move * walksp;

vsp = vsp + grv;

if(place_meeting(x,y+1,oFloorWall))&&(key_jump)
{
	vsp = -9;
	//sprite_index = zero_saltando;
	//image_speed = 0;
}

if(place_meeting(x+hsp,y,oFloorWall))
{
	while(!place_meeting(x+sign(hsp),y,oFloorWall))
	{
		x = x + sign(hsp);
	}
	hsp = 0;
}
x = x + hsp;

if(place_meeting(x,y+vsp,oFloorWall))
{
	while(!place_meeting(x,y+sign(vsp),oFloorWall))
	{
		y = y + sign(vsp);
	}
	vsp = 0;
}

y = y + vsp;

if(place_meeting(x,y+1,oFloorWall))
{
	sprite_index = zero_parado;
	image_speed = 0;
	if(sign(vsp)) > 0 
	{
	  image_index = 1;
	}
	else
	{
	  image_index = 0;
	}
}
*/