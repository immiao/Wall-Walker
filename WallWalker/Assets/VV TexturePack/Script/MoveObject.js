#pragma strict

var PrimaryRot : float = 15.0;
var SecondaryRot : float = 10.0;
var TertiaryRot : float = 5.0;

function Start () {

}

function Update () {
	transform.Rotate(Vector3(0, PrimaryRot, 0) * Time.deltaTime, Space.World);
	transform.Rotate(Vector3(SecondaryRot, 0, 0) * Time.deltaTime, Space.World);
	transform.Rotate(Vector3(0, 0, TertiaryRot) * Time.deltaTime, Space.World);

}