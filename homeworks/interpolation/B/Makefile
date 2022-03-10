test_qspline.png:out.txt test_qspline.gpi
	pyxplot test_qspline.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs interpolator.dll
	mcs -target:exe -reference:interpolator.dll $<

interpolator.dll:interpolator.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll *.png
