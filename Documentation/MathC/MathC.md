# The documentation for SLIDDES MathC
Allthough all functions have a summary, some functions are more complex / rely on other functions.
This documentation should give some (hopefully) helpful insight on those functions.
To be clear, this documentation does not cover all functions, only those that are more complex.

## Calculating a velocity arch for an object to hit a target
[keywords: CalculateVelocityToHitTarget, TimePointCalculateVelocityToHitTarget]

### Example 1. Velocity
If you want to trow a brick from the player to a window you will need the following:
- The player position
- The window position

Using CalculateVelocityToHitTarget:
```
Vector3 pos1 = player.position; // change player
Vector3 pos2 = window.position; // change window

Vector3 vel = SLIDDES.MathC.CalculateVelocityToHitTarget(pos1, pos2);
// You now have the velocity needed for the object to land in the window
// brick.velocity = vel;
```

### Example 2. Drawing the arch with a LineRenderer
If you want to show the arch before trowning:
```
VisualizeArch(vel);

private void Visualize(Vector3 vel)
{
    for(int i = 0; i < 10; i++)
    {
        Vector3 pos = SLIDDES.MathC.TimePointCalculateVelocityToHitTarget(vel, i / 10f;
        lineRenderer.SetPosition(i, pos); // assign a lineRenderer
    }
}
```