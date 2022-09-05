# LSWtask
At first I made a fast sprite for the player, the shopkeeper and the buildings, them  I started to make the player Walk and intereact, no animations to begin, used the GetAxis to make the plyer movements and a TriggerEnter2D function to detect if the player is near something that he can Interact. If the player is next to something he can Interact a “Press Space” icon apears over his head and if space bar is pressed the player would Interact, in this case he would Interact with the shopkeeper.

Now the player need to buy some clothes, but first he needs a place to storage them, so I made a inventory sprite and attach it to the player using a canvas. When the user press “i” the inventory is activated and disactivated. To the inventory I made slots and items and used the drag and drop system to move the items with the mouse. I classified the items and the slots, this way the user can’t put a hat in a tshirt slot and it would help with the salling system in the future. In the top of the inventory is the amount of Money the player have, the GameController takes care of it.

The GameController controls the menu system, it shows and closes the dialog, inventory and shop menu. 
The Drag and Drop script controls the sallings, when a item is set in a diferente slot, the script check where this item came from and Where it is going and do the payments.
Now to do the clothes system I started with the animations, I made some clothe sprites and player animations, them I made the items scriptable objects and create the items. Them I made some copys of the player to became clothes sockets, and start the clothe change system. When the user put a item in a equipment slot the item animation is choosed and apears in the right socket.

I think my pixel art abilitys needs to be improved but I made the main requests with the time I had, thanks for read.
