# AI Search Project

## Project Overview

This project showcases the implementation of the **A* (A-star) search algorithm** in Unity, focusing on its application for pathfinding in a grid environment. The primary objective is to efficiently navigate from a starting point to a designated target while dynamically avoiding obstacles. Users can experiment with a variety of search algorithms, including:

- Depth-First Search (DFS)
- Depth-First Search with Expansion (DFS + Exp)
- Depth-Limited Search (DLS)
- Iterative Deepening Search (IDS)
- Uniform Cost Search (UCS)
- Greedy Best-First Search (GBFS)
- A* (A-star)
- Iterative Deepening A* (IDA*)
- Heuristic Search

This project provides valuable insights into the performance and effectiveness of these algorithms in different scenarios, making it an excellent tool for understanding the principles of pathfinding and search strategies.

### Key Features:
- **Grid-Based Pathfinding:** The map is divided into tiles where the object calculates and navigates the most efficient route to the target.
- **Multi-Algorithm Support:** Implements various search algorithms, including Depth-First Search (DFS), DFS with expansion, Depth-Limited Search (DLS), Iterative Deepening Search (IDS), Uniform Cost Search (UCS), Greedy Best-First Search (GBFS), A* (A-star), and Iterative Deepening A* (IDA*). Each algorithm can be selected to compare performance and pathfinding efficiency.
- **Heuristic-Based Pathfinding:** Utilizes heuristic approaches alongside traditional algorithms to enhance decision-making and optimize route calculations, providing flexible options for different pathfinding challenges.
- **Visual Feedback with VFX:** Offers engaging visualizations through VFX animations that illustrate the pathfinding process. Users can watch as the algorithms calculate paths on an isometric game board, enhancing their understanding of each algorithm's operation.
- **Interactive Unity Experience:** Built within Unity, the project provides an interactive game-like experience that allows users to engage with the algorithms in a visually appealing and educational manner.

## Getting Started

### Prerequisites
- Windows Os
- Python Version 3 or above

### Installation
1. Download The Build.zip and the pyhton folder from the repo
   
## Running the Project

To visualize the A* algorithm steps, follow these steps:

1. **Run the Python Main Code**:
   - Execute the `main.py` script in your preferred Python environment. This will generate a JSON file containing valid moves for your test case.

2. **Match Test Case Names**:
   - Ensure that the name of chosen test case in main file matches the test case you have loaded in the Unity application.

3. **Launch the Unity Application**:
   - Open the Unity application and load the desired scene.

4. **Calculate and Visualize**:
   - Click the "Calculate" button in the Unity interface to visualize the steps of the choosen algorithm.
   - You can also compare the run times to verify the functionality of your code.
