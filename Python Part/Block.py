class Block:
    def __init__(self, position: list):
        self.position = position
        self.is_vertical = False
        if position[0][0] != position[1][0]:
            self.is_vertical = True
