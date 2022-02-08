default: out.txt

out.txt : week3.exe
	mono week3.exe > out.txt

week3.exe : week3.cs
	mcs week3.cs

.PHONY: clean
clean:
	rm -f out.txt hello.exe
