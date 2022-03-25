all:out.txt
	cat out.txt

out.txt:main.exe
	mono $< > $@

main.exe:main.cs matrix.dll vector.dll evd.dll
	mcs -t:exe -r:matrix.dll -r:vector.dll -r:evd.dll $<

evd.dll:evd.cs matrix.dll vector.dll
	mcs -t:library -r:matrix.dll -r:vector.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll
