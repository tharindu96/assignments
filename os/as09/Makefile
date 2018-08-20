CC := gcc
LD := gcc

CCFLAGS := -pthread
LDFLAGS := -pthread

BIN=01

all: $(BIN)

%.o: %.c
	$(CC) $(CCFLAGS) -o $@ -c $^

$(BIN): $(BIN).o
	$(LD) $(LDFLAGS) -o $@ $^

clean:
	rm -f *.o
	rm -f $(BIN)
