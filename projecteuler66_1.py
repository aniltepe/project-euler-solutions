import math

def is_square(apositiveint):
  x = apositiveint // 2
  seen = set([x])
  while x * x != apositiveint:
    x = (x + (apositiveint // x)) // 2
    if x in seen: return False
    seen.add(x)
  return True

for D in range(2, 1001):
  if is_square(D):
    continue
  y = 1
  x = -1
  while True:
    if is_square(D * (y ** 2) + 1):
      x = math.sqrt(D * (y ** 2) + 1)
      break
    else:
      y += 1

  print(str(int(x)) + "² - " + str(D) + "." + str(y) + "² = 1")