import java.util.HashSet;
import java.util.Set;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int x = scanner.nextInt();
        int y = scanner.nextInt();
        int p = scanner.nextInt();
        System.out.println(game(x, y, p));
    }

    public static int game(int x, int y, int p) {
        if (y - x > 0) {
            int[] state1 = {x, y - x, p};
        } else {
            return 1;
        }
        Set<int[]> states = new HashSet<>();
        states.add(state1);
        int i = 1;
        Set<int[]> A = new HashSet<>();
        A.add(state1);
        while (!A.isEmpty()) {
            Set<int[]> B = new HashSet<>();
            i++;
            int m1_ = 10000;
            int m2_ = 10000;
            int m4_ = 10000;
            int m6_ = 10000;
            for (int[] state : A) {
                int x = state[0];
                int y = state[1];
                int z = state[2];
                if (x >= y + z) {
                    return i;
                }
                int b = (x >= z) ? x - z : 0;
                List<Integer> J = new ArrayList<>();
                for (int j = 0; j <= x; j++) {
                    if (b <= j && j <= y && 2 * x - z - j > 0) {
                        J.add(j);
                    }
                }
                if (p < x) {
                    J = J.stream().filter(j -> (y - j) * x < y * (2 * x - z - j)).collect(Collectors.toList());
                }
                for (int j : J) {
                    int new_y = (y - j <= 0) ? 0 : y - j;
                    int new_z = (new_y == 0) ? ((z - x + j > 0) ? z - x + j : 0) : ((z - x + j > 0) ? z - x + j + p : p);
                    int new_x = 2 * x - z - j;
                    int[] new_state = {new_x, new_y, new_z};
                    if (new_y <= 0 && new_z <= 0) {
                        return i;
                    } else if (new_x >= new_y + new_z) {
                        return i + 1;
                    } else if (new_y == 0) {
                        if (new_x >= new_z) {
                            return i + 1;
                        } else {
                            B.add(new_state);
                            states.add(new_state);
                            if ((double) new_z / new_x < m1_) {
                                m1_ = (double) new_z / new_x;
                                m1 = new_state;
                            }
                            if ((double) new_y / new_x < m2_) {
                                m2_ = (double) new_y / new_x;
                                m2 = new_state;
                            }
                            if ((double) (new_y + new_z) / new_x < m4_) {
                                m4_ = (double) (new_y + new_z) / new_x;
                                m4 = new_state;
                            }
                            if ((new_y + new_z) < m6_) {
                                m6_ = (new_y + new_z);
                                m6 = new_state;
                            }
                            break;
                        }
                    } else {
                        if ((double) new_z / new_x < m1_) {
                            m1_ = (double) new_z / new_x;
                            m1 = new_state;
                        }
                        if ((double) new_y / new_x < m2_) {
                            m2_ = (double) new_y / new_x;
                            m2 = new_state;
                        }
                        if ((double) (new_y + new_z) / new_x < m4_) {
                            m4_ = (double) (new_y + new_z) / new_x;
                            m4 = new_state;
                        }
                        if ((new_y + new_z) < m6_) {
                            m6_ = (new_y + new_z);
                            m6 = new_state;
                        }
                        if (new_x * 1.5 >= new_z && !states.contains(new_state)) {
                            states.add(new_state);
                            B.add(new_state);
                        }
                    }
                }
            }
            if (B.isEmpty()) {
                A = new HashSet<>();
            } else if (B.size() == 1) {
                A = B;
            } else {
                A = new HashSet<>(m1, m2, m4, m6);
            }
        }
        return -1;
    }
}
