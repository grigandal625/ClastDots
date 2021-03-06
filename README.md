# ClastDots
Кластеризация точек в пространстве

Точки x,y называются **близлежащими**, если ***ρ*** **(x,y) < R**, где ***ρ*** - метрика пространства, **R** - фиксированный параметр

Множество точек **K** называется **кластером**, если ∀**x**∈**K** ∃**y**∈**K**(**ρ(x,y)<R**), т.е. каждая точка, входящая в кластер,
окружена некоторым количеством близлежащих точек, у каждой из которых, в свою очередь, тоже есть близлежащие.

Граничной точкой кластера называется точка, у которой хотя бы в одном из квадрантов нет ни одного соседа.

Границей кластера называется множество граничных точек. У любого кластера, состоящего из конечного числа точек, есть хотя бы одна граница.
Границ может быть 2 или более, если кластер содержит «полости».

В данном репозитории представлен проект по кластеризации и выявлению границ кластеров различных множеств точек.

Графика - OpenGl Tao framework
