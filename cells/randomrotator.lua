name = "Random Rotator"
id = "RANDOMROTATER"
author = "Milenakos"
texture = "randomrotator.png"
updateAfter = "CCWROTATER"
-- updateAfter = "CWROTATER" etc
-- if more than one mod wants the spot, sort reverse-alphabetically
-- if not set, updates last
math.randomseed(os.time())

function Step ()
    local amount = math.random(1, 3)
    this.Rotate(amount)
    Cell(this.x + 1, this.y).Rotate(amount)
    Cell(this.x - 1, this.y).Rotate(amount)
    Cell(this.x, this.y + 1).Rotate(amount)
    Cell(this.x, this.y - 1).Rotate(amount)
end