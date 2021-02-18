# IA-Prog
Projet module "Programmation IA" : Pacman  

## Auteurs
HALLER Antoine  
LECOUFFE Gauthier  

## Algorithme utilise
A*          
Cout de déplacement haut, bas, droite, gauche: 10 (1 * 10)  
Cout de déplacement en diagonale: 14 (squareroot(2) * 10)  
Calcul de gCost (cout de deplacement depuis la cible), de hCost (cout de deplacement depuis la position de depart)  
Permet de determiner fCost (gCost + hCost)  
Exploration des voisins et du cout fCost.  
Exploration de la case avec le fCost le plus petit.  
Si plusieurs cases ont le même fCost, on choisit celui avec le plus petit hCost.  
Et ainsi de suite.  

## Optimisation realise
On ne garde dans le path seulement les cases forçant un changement de direction.  
ATTENTION: quelques bugs, certains angles de murs sont coupes ...  
