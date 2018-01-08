/* README
 * 
 * Movement mechanics somewhat explained;
 * Used in kz, surf and sandbox scenes. Runner scene is simpler movement with some extras, similar to something like Mirrors edge.
 * 
 * 
 * Player can gain speed various ways but on the ground friction is applied and speed is reduced to normal over time.
 * Player can maintain current speed by jumping. Current code uses queue jumping, meaning that holding space will make player jump automatically next time player lands. Friction calculation are also ignored.
 * Other option for queue jumping would be requiring player to time jumps perfectly, or system that stores inputs for short period of time and therefore requiring timing while still allowing slight mistakes.
 * This might also work better depending on engine used. In source player has to time +jump with exact same tick when landing happens for jump to be considered perfect. But because input jump is actually +jump and -jump commands, even with perfect timing player has 50% change of success.
 * Allowing for margin of error would get rid off such inconsistencies.
 * 
 * 
 * Air strafing;
 * Way to control direction while in the air. Common way of turning is to hold left/right movement keys and move mouse slowly to that direction. Doing so also increases speed of the player.
 * Higher sync between movement keys and mouse results in more speed.
 * 
 * 
 * Strafe jumping;
 * Used to gain speed fast in a straight line. Hold forward + use left/right keys along with camera movement.
 * Jumping when touching the ground to maintain speed.
 * 
 * 
 * Bunny-hop, commonly referred as Bhop;
 * Faster turns over strafe jumping. Air strafing to gain speed / control movement. Optimal speed and number of strafes depends on settings.
 * High air control allows for fast turns without losing any speed.
 * Also allows for higher number strafes during single jump, allowing player to potentially gain more speed in same amount of time.
 * Jumping when touching the ground to maintain speed.
 * 
 * Worth noting that with both systems enabled, easiest way is to use strafe jumping as way of gaining speed and airstrafes to controll overall movement.
 * Gaining speed with strafe jumping is limited to more forward motion while bhop allows for gaining speed within a small area.
 * 
 * 
 * Surfing;
 * Sliding along angled surfaces. Going downwards will cause player to accelerate and going upwards will deaccelerate player.
 * 
 * 
 * Double jump;
 * Jumping again shortly after jumping results in higher jump.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */