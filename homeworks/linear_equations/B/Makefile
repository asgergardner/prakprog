all:out.txt
	cat out.txt

out.txt:main.exe
	mono $< > $@

main.exe:main.cs matrix.dll vector.dll lineq.dll 
	mcs -target:exe -reference:matrix.dll -reference:lineq.dll -reference:vector.dll $<

lineq.dll:lineq.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll:vector.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt
