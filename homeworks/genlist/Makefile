all:out.txt
	cat $<

out.txt:main.exe input.txt
	mono $< < input.txt > $@ 

main.exe:main.cs genlist.dll
	mcs -target:exe -reference:genlist.dll $<

genlist.dll:genlist.cs
	mcs -target:library $<

.PHONY:
clean: 
	rm out.txt *.exe *.dll
