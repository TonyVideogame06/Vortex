/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
//Overwrite old save
if (file_exists(SAVEFILE))
{
	file_delete(SAVEFILE);
}

//Create new save
var file;
file = file_text_open_write(SAVEFILE);
file_text_write_real(file,room);
file_text_write_real(file,x);
file_text_write_real(file,y);
file_text_close(file);