/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
hsp = 3;
vsp = -4;
grv = 0.3;
done = 0;

image_speed = 0;
image_index = 0;
ScreenShake(6,25);
audio_play_sound(snDeath,10,false);
game_set_speed(30,gamespeed_fps);
with(oCamera)
{
	follow = other.id;
}