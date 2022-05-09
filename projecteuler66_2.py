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

def int2list(i):
  rtn = []
  s = str(i)
  for i in range(len(s)):
    rtn.append(int(s[i]))
  return rtn
  
def sum(l1, l2):
  rtn = []
  excess = 0
  diff = len(l1) - len(l2)
  if diff > 0:
    for i in range(diff):
      l2.insert(0, 0)
  else:
    for i in range(diff * -1):
      l1.insert(0, 0)
  for i in range(len(l1) - 1, -1, -1):
    s = l1[i] + l2[i] + excess
    rtn.insert(0, s % 10)
    excess = int(s / 10)
    if i == 0 and excess != 0:
      rtn.insert(0, excess)
  return rtn

def multiply(l1, l2):
  rtn = [0]
  for i in range(len(l2) - 1, -1, -1):
    internal = []
    excess = 0
    for j in range(len(l1) - 1, -1, -1):
      m = l2[i] * l1[j] + excess
      internal.insert(0, m % 10)
      excess = int(m / 10)
      if j == 0 and excess != 0:
        internal.insert(0, excess)
    for j in range(0, len(l2) - 1 - i):
      internal.append(0)
    rtn = sum(rtn, internal)
  return rtn

def list2str(l):
  s = ""
  for n in l:
    s += str(n)
  return s

# max_x = -1
# max_D = -1
script_dir = os.path.dirname(__file__)
new_file = open(script_dir + "/pe66_.txt", "w+")
lines = []

for D in range(2, 1001):
  if is_square(D):
    continue
  fractions = find_fractions(D)
  r = len(fractions) - 2
  recurrence = 2 * r + 1 if r % 2 == 0 else r
  p = []
  q = []
  p.append(int2list(fractions[0]))
  p.append(int2list(fractions[0] * fractions[1] + 1))
  q.append(int2list(1))
  q.append(int2list(fractions[1]))
  for i in range(2, recurrence + 1):
    n = i if i < len(fractions) else i - r - 1
    p.append(sum(multiply(int2list(fractions[n]), p[i - 1]), p[i - 2]))
    q.append(sum(multiply(int2list(fractions[n]), q[i - 1]), q[i - 2]))
  x = p[-1]
  y = q[-1]
  new_line = ""
  # new_line += "True    " if x * x - (D * y * y) == 1 else "False    "
  new_line += list2str(x) + "² - " + str(D) + "." + list2str(y) + "² = 1\n"
  lines.append(new_line)
  # if x > max_x:
  #   max_x = x
  #   max_D = D

# print("largest x = " + str(max_x) + " obtained when D = " + str(max_D))

new_file.writelines(lines)
new_file.close()

  
