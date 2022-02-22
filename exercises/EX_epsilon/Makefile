all:out.txt
	cat $<

out.txt:main.exe
	mono $< > $@

main.exe:main.cs epsilon.dll
	mcs -target:exe -reference:epsilon.dll main.cs

epsilon.dll:epsilon.cs
	mcs -target:library $<

.PHONY:
clean:
	rm *.exe *.txt *.dll
