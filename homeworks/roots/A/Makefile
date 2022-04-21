all:out.txt
	cat out.txt

out.txt:main.exe
	mono $< > $@

main.exe:main.cs vector.dll matrix.dll roots.dll
	mcs -t:exe -r:vector.dll -r:matrix.dll -r:roots.dll $<

roots.dll:roots.cs vector.dll matrix.dll lineq.dll
	mcs -t:library -r:vector.dll -r:matrix.dll -r:lineq.dll $<

lineq.dll:lineq.cs vector.dll matrix.dll
	mcs -t:library -r:vector.dll -r:matrix.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt
