test_cspline.png:out.txt test_cspline.gpi
	pyxplot test_cspline.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs interpolator.dll
	mcs -target:exe -reference:interpolator.dll $<

interpolator.dll:interpolator.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll *.png
