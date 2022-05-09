def is_square(apositiveint):
  x = apositiveint // 2
  seen = set([x])
  while x * x != apositiveint:
    x = (x + (apositiveint // x)) // 2
    if x in seen: return False
    seen.add(x)
  return True

x = 2
Ds = []
while(True):
    for D in range(2, 1001):
        if (is_square(D) | D in Ds):
            continue
        exitDloop = False
        for y in range(1, int(x / 2 + 2)):
            if (x ** 2 - (D * (y ** 2)) == 1):
                Ds.append(D)
                print("x = " + str(x) + ", D = " + str(D) + ", y = " + str(y) + ";  count of Ds: " + str(len(Ds)))
                exitDloop = True
                break
        if exitDloop:
            break
    x += 1
