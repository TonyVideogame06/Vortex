// Allows one line setup of major text drawing vars
// Requiring all four prevents silly coders from forgettig one
// And therefore creating a dumb dependency on other event callls
// (Then wondering why their text changes later in development)

draw_set_colour(argument0);
draw_set_font(argument1);
draw_set_halign(argument2);
draw_set_valign(argument3);