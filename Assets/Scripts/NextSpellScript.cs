using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpellScript : MonoBehaviour {

	public Sprite fireballSprite, missileSprite, yeetSprite, forgetSprite, teleportSprite, healSprite;
	public SpriteRenderer nextSpellRenderer;
    public string nexSpell;

    private void Update()
    {
        nextSpellRenderer.transform.LookAt(Camera.main.transform);
    }

    public void ChangeSpell (string nextSpell) {
        nexSpell = nextSpell;
        if (nextSpell == "fireball")
			nextSpellRenderer.sprite=fireballSprite;
		else if (nextSpell == "missle")
			nextSpellRenderer.sprite=missileSprite;
		else if (nextSpell == "yeet")
			nextSpellRenderer.sprite=yeetSprite;
		else if (nextSpell == "forget")
			nextSpellRenderer.sprite=forgetSprite;
		else if (nextSpell == "teleport")
			nextSpellRenderer.sprite=teleportSprite;
		else if (nextSpell == "heal")
			nextSpellRenderer.sprite=healSprite;
		
	}
}
