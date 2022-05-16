all:out.txt
	cat out.txt

out.txt : math.exe
	mono math.exe > out.txt

math.exe : math.cs
	mcs math.cs

.PHONY: clean
clean:
	rm -f out.txt hello.exe
