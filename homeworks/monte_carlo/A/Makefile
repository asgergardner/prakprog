all:out.txt
	cat out.txt

out.txt:main.exe
	mono $< > $@

main.exe:main.cs mc.dll vector.dll
	mcs -t:exe -r:mc.dll -r:vector.dll $<

mc.dll:mc.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll
