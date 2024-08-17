class_name RaySpriteSheetSaver
extends ResourceFormatSaver
	
	
func _recognize(resource: Resource) -> bool:
	return resource is RaySpriteSheet


func _save(resource: Resource, path: String, flags: int) -> Error:
	var file = FileAccess.open(path, FileAccess.WRITE)
	if not file:
		return ERR_FILE_CANT_OPEN

	var data = resource._to_dict()
	file.store_var(data)
	file.close()
	return OK
