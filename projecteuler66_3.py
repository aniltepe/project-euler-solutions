# pell equation & periodic continued fraction
import os
import math

def is_square(apositiveint):
  x = apositiveint // 2
  seen = set([x])
  while x * x != apositiveint:
    x = (x + (apositiveint // x)) // 2
    if x in seen: return False
    seen.add(x)
  return True

def find_fractions(apositiveint):
  sqr = math.sqrt(apositiveint)
  flr = int(sqr)
  fractions = []
  fractions.append(flr)
  recip = 1 / (sqr - flr)
  frc = int(recip)
  fractions.append(frc)
  while frc != flr * 2:
    recip = 1 / (recip - frc)
    frc = int(recip)
    fractions.append(frc)
  return fractions

max_x = -1
max_D = -1
script_dir = os.path.dirname(__file__)
new_file = open(script_dir + "/pe66_.txt", "w+")
lines = []

for D in range(13, 1001):
  if is_square(D):
    continue
  fractions = find_fractions(D)
  r = len(fractions) - 2
  recurrence = 2 * r + 1 if r % 2 == 0 else r
  pn_2 = fractions[0]
  pn_1 = fractions[0] * fractions[1] + 1
  qn_2 = 1
  qn_1 = fractions[1]
  p = -1
  q = -1
  n = 2
  while p * p - D * q * q != 1:
    n = n if n < len(fractions) else n - r - 1
    p = fractions[n] * pn_1 + pn_2
    q = fractions[n] * qn_1 + qn_2
    pn_2 = pn_1
    pn_1 = p
    qn_2 = qn_1
    qn_1 = q
    n += 1
  x = p
  y = q
  new_line = ""
  # new_line += "True    " if x * x - (D * y * y) == 1 else "False    "
  new_line += str(x) + "² - " + str(D) + "." + str(y) + "² = 1\n"
  lines.append(new_line)
  if x > max_x:
    max_x = x
    max_D = D

print("largest x = " + str(max_x) + " obtained when D = " + str(max_D))

new_file.writelines(lines)
new_file.close()

  
