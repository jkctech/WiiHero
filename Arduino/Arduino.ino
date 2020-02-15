#include <WiiChuck.h>

/*
 * As marked on the WiiChuck library page,
 * not all bytes are actually used.
 * This will be the list of the ones we DO care about.
 * (The numbers are off-by-one from the documentation for some reason.)
 * https://github.com/madhephaestus/WiiChuck
 */

Accessory   guitar;
int         ids[] = {0,6,7,10,11,12,13,14,-1};

void setup() {
	Serial.begin(115200);
	guitar.begin();
}

void loop() {
  int   i = 0;

  guitar.readData();
  while (ids[i] != -1)
  {
    // Loop over the array values and put them to serial as a char
    Serial.print(guitar.values[ids[i]]);
    if (ids[i + 1] != -1)
      Serial.print(',');
    i++;
  }
  Serial.print('\n');
}
