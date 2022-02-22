all: out.txt
	cat out.txt

out.txt:hello.exe
	mono $< > $@

hello.exe:hello.cs
	mcs $<

.PHONY:
clean:
	rm *.exe *.txt
