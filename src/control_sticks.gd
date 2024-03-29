class_name ControlSticks extends Control

@onready var world := get_tree().root.get_node("World3D") as World
@onready var stick_circle_container := get_node("StickCircleContainer") as Control
@onready var stick_button_container := get_node("StickButtonContainer") as Control
@onready var game_viewport := get_viewport()

@export var max_distance: float = 47

var mouse_position: Vector2
var screen_pressed := false

func _ready():
	visible = false


func _process(_delta: float) -> void:
	if world.state == world.GAMESTATE.PAUSED: return

	mouse_position = game_viewport.get_mouse_position()

	if screen_pressed:
		if position.distance_to(mouse_position) <= max_distance:
			stick_button_container.global_position = mouse_position
		else:
			var direction = (mouse_position - position).normalized()
			stick_button_container.global_position = position + direction * max_distance
	

func handle_left_mouse_click():
	position = game_viewport.get_mouse_position()
	screen_pressed = true
	visible = true

func handle_left_mouse_release():
	screen_pressed = false
	visible = false