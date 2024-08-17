class_name RaySpriteSheet
extends Resource

@export var sprites : Dictionary = {}


func add_sprite(name: String, texture: Texture2D, rect: Rect2):
	sprites[name] = AtlasTexture.new()
	sprites[name].atlas = texture
	sprites[name].region = rect


func get_sprite(name: String) -> AtlasTexture:
	if sprites.has(name):
		return sprites[name]
	return null


func _to_dict() -> Dictionary:
	return sprites


func _from_dict(data: Dictionary):
	sprites = data
