@tool
extends EditorPlugin

var import_plugin_spritesheet = null

func get_name():
	return "rTextPacker Binary SpriteSheet Importer"


func _enter_tree():
	var loader = preload("res://addons/rtex_binary_spritesheet_importer/ray_sprite_sheet_loader.gd").new()
	var saver = preload("res://addons/rtex_binary_spritesheet_importer/ray_sprite_sheet_saver.gd").new()    
	ResourceLoader.add_resource_format_loader(loader)
	ResourceSaver.add_resource_format_saver(saver)
	
	import_plugin_spritesheet = preload("res://addons/rtex_binary_spritesheet_importer/rtex_file_importer.gd").new()
	add_import_plugin(import_plugin_spritesheet)


func _exit_tree():
	var loader = preload("res://addons/rtex_binary_spritesheet_importer/ray_sprite_sheet_loader.gd").new()
	var saver = preload("res://addons/rtex_binary_spritesheet_importer/ray_sprite_sheet_saver.gd").new()    
	ResourceLoader.remove_resource_format_loader(loader)
	ResourceSaver.remove_resource_format_saver(saver)
	
	remove_import_plugin(import_plugin_spritesheet)
	import_plugin_spritesheet = null
