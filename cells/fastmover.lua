name = "Fast Mover"
id = "FASTMOVER"
author = "Milenakos"
texture = "fastmover.png"
updateAfter = "MOVER"
-- updateAfter = "CWROTATER" etc
-- if more than one mod wants the spot, sort reverse-alphabetically
-- if not set, updates last

function Step ()
    Cell(1, 1).Clone(2, 2, 0)
    this.Push(this.direction, 1)
    this.suppressed = false
end

-- this code is taken from mover cell without changes.
function Push (dir, bias)
    if (this.suppressed) then
        return this.Push(dir, bias)
    end

    if (this.rotation == dir) then
        bias = bias + 1
    elseif ((dir + 2) % 4 == this.rotation) then
        bias = bias - 1
    end
    return this.Push(dir, bias)
end
