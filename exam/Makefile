all:out.txt HGS.png
	cat $<

HGS.png:plotHGS.gpi
	pyxplot $<

out.txt:main.exe
	mono $< > $@

main.exe:main.cs vector.dll matrix.dll lagrange.dll
	mcs -t:exe -r:vector.dll,matrix.dll,lagrange.dll $<

lagrange.dll:lagrange.cs vector.dll matrix.dll roots.dll
	mcs -t:library -r:vector.dll,matrix.dll,roots.dll $<

roots.dll:roots.cs lineq.dll vector.dll matrix.dll
	mcs -t:library -r:lineq.dll,vector.dll,matrix.dll $<

lineq.dll:lineq.cs vector.dll matrix.dll
	mcs -t:library -r:vector.dll,matrix.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.dll *.exe *.txt *.png
