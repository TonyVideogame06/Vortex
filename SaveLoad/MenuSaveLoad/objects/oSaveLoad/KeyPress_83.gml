/// @description Inserte aquí la descripción
// Puede escribir su código en este editor

//Create a root list
var _root_list = ds_list_create();

// for every instance, create map
with (pSaveMe)
{
	var _map = ds_map_create();
	ds_list_add(_root_list,_map);
	ds_list_mark_as_map(_root_list,ds_list_size(_root_list)-1);
	
	var _obj = object_get_name(object_index);
	ds_map_add(_map,"obj",_obj);
	ds_map_add(_map,"y",y);
	ds_map_add(_map,"x",x);
	//ds_map_add(_map,"spd",spd);
	ds_map_add(_map,"image_index",image_index);
	ds_map_add(_map,"image_blend",image_blend);
	
}
//Wrap the root LIST up in a MAP
var _wrapper = ds_map_create();
ds_map_add_list(_wrapper,"ROOT",_root_list);

//Save all of this to a string
var _string = json_encode(_wrapper);
SaveStringToFile("savedgame.sav",_string);

//Nuke the data
ds_map_destroy(_wrapper);

show_debug_message("Game saved!");