using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand attackCommand, jumpCommand, skillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> executeCommands = new Stack<ICommand>();
        private void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "Fireball");
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))//공격기능
            {
                attackCommand.Execute();
                executeCommands.Push(attackCommand);
            }
            else if(Input.GetKeyDown(KeyCode.W))//점프기능
            {
                jumpCommand.Execute();
                executeCommands.Push(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E))//스킬기능
            {
                skillCommand.Execute();
                executeCommands.Push(skillCommand);
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))//공격
            {
                commandQueue.Enqueue(attackCommand);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))//점프
            {
                commandQueue.Enqueue(jumpCommand);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))//스킬
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 명령 실행");

                while (commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                    executeCommands.Push(command);
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))//뒤로돌아가기기능=취소하기기능
            {
                if (executeCommands.Count > 0)
                {
                    ICommand lastCommand = executeCommands.Pop();//가장 최근에 실행한 명령
                    Debug.Log($"명령 취소: {lastCommand.GetType().Name}");

                    lastCommand.Cancel();//Undo
                }
                else
                    Debug.Log("되돌릴 명령이 없습니다");
            }
        }
    }

}
