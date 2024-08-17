@tool
extends EditorImportPlugin

enum Preset { PRESET_DEFAULT }


func _get_importer_name() -> String:
	return "ray_sprite_sheet_importer"


func _get_visible_name() -> String:
	return "Ray Sprite Sheet Importer"


func _get_recognized_extensions() -> PackedStringArray:
	return ["rtpb"]


func _get_save_extension() -> String:
	return "res"


func _get_resource_type() -> String:
	return "RaySpriteSheet"
	
	
func _get_preset_count():
	return Preset.size()


func _get_preset_name(preset):
	match preset:
		Preset.PRESET_DEFAULT: return "Default"


func _get_import_options(path, preset_index):
	return []


func _get_option_visibility(path, option_name, options):
	return true


func _get_import_order():
	return 200


func _get_priority():
	return 1.0


func _import(p_source_file: String, p_save_path: String, p_options: Dictionary, p_platform_variants: Array, p_gen_files: Array) -> int:
	var file := FileAccess.open(p_source_file, FileAccess.READ)
	if file == null:
		return ERR_FILE_CANT_OPEN
	
	var data := file.get_buffer(file.get_length())
	file.close()
	
	var sprite_sheet := RaySpriteSheet.new()
	
	var signature = ""
	for i in range(4):
		signature += char(data[i])
	if signature != "rTPb":
		return ERR_FILE_CORRUPT
	
	var version = data.decode_s16(4)
	if version != 200:
		return ERR_FILE_UNRECOGNIZED
	
	var sprite_count = data.decode_s32(8)
	var offset = 24
	
	for i in range(sprite_count):
		var name_bytes = data.slice(offset, offset + 128)
		var name = ""
		for j in range(128):
			if name_bytes[j] != 0:
				name += char(name_bytes[j])
		name = name.strip_edges()
		offset += 128
		
		var origin_x = data.decode_s32(offset)
		var origin_y = data.decode_s32(offset + 4)
		var pos_x = data.decode_s32(offset + 8)
		var pos_y = data.decode_s32(offset + 12)
		var src_width = data.decode_s32(offset + 16)
		var src_height = data.decode_s32(offset + 20)
		offset += 48
		
		var rect = Rect2(Vector2(pos_x, pos_y), Vector2(src_width, src_height))
		var texture = _get_texture(p_source_file)
		
		sprite_sheet.add_sprite(name, texture, rect)

	ResourceSaver.save(sprite_sheet, _get_save_path(p_source_file))	
	return OK
	
		
func _get_texture(p_source_file: String) -> Texture2D:
	var folder = p_source_file.get_base_dir()
	var base_name = p_source_file.get_file().get_basename()
	var texture_path = folder + "/" + base_name + ".png"
	return load(texture_path)
	
	
func _get_save_path(p_source_file: String) -> String:
	var folder = p_source_file.get_base_dir()
	var base_name = p_source_file.get_file().get_basename()
	return folder + "/" + base_name + ".res"
