class_name RaySpriteSheetLoader
extends ResourceFormatLoader

func _get_recognized_extensions() -> PackedStringArray:
	return ["res"]


func _handles_type(type: StringName) -> bool:
	return type == "RaySpriteSheet"


func _load(path: String, original_path: String, use_sub_threads: bool, cache_mode: int) -> Resource:
	var file = FileAccess.open(path, FileAccess.READ)
	if not file:
		return null

	var data = file.get_var()
	file.close()
	
	var resource = RaySpriteSheet.new()
	resource._from_dict(data)
	return resource
