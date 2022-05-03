all:out.txt
	cat $<

out.txt:main.exe
	mono $< > $@

main.exe:main.cs min.dll vector.dll
	mcs -t:exe -r:min.dll,vector.dll $< 

min.dll:min.cs matrix.dll vector.dll
	mcs -t:library -r:matrix.dll,vector.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.dll
